#!/usr/bin/env python3
"""
Create base CSVs for MercaditoMovil. No external deps.
Reads GeoLocations/locations.csv if present (ASCII, no accents).
Writes all CSVs under MercaditoMovil.Infrastructure/DataFiles/.
Run from anywhere; paths are resolved from this script's directory.
"""

import csv
import os
import random
import string
from datetime import date, timedelta

# ---------- paths ----------
SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
INFRA_DIR = os.path.normpath(os.path.join(SCRIPT_DIR, "..", ".."))
DATA_DIR = os.path.join(INFRA_DIR, "DataFiles")
DIRS = {
    "geo": os.path.join(DATA_DIR, "GeoLocations"),
    "markets": os.path.join(DATA_DIR, "Markets"),
    "people": os.path.join(DATA_DIR, "People"),
    "producers": os.path.join(DATA_DIR, "Producers"),
    "catalogs": os.path.join(DATA_DIR, "Catalogs"),
    "commerce": os.path.join(DATA_DIR, "Commerce"),
}
for d in DIRS.values():
    os.makedirs(d, exist_ok=True)

LOCATIONS_CSV = os.path.join(DIRS["geo"], "locations.csv")
MARKETS_CSV   = os.path.join(DIRS["markets"], "markets.csv")
USERS_CSV     = os.path.join(DIRS["people"], "users.csv")
PRODUCERS_CSV = os.path.join(DIRS["producers"], "producers.csv")
CATALOG_CSV   = os.path.join(DIRS["catalogs"], "product_catalog.csv")
PPROD_CSV     = os.path.join(DIRS["commerce"], "producer_products.csv")

# ---------- data: markets (GAM + placeholder) ----------
GAM_PROVINCES = {"San Jose", "Heredia", "Alajuela", "Cartago"}
MARKETS = [
    ("MKT-000","Fuera de cobertura GAM","Cobertura","NoGAM","FueraDeGAM"),
    ("MKT-001","Feria del Agricultor Heredia - La Perla","Heredia","Heredia","Mercedes Norte"),
    ("MKT-002","Feria del Agricultor Grecia","Alajuela","Grecia","La Arena"),
    ("MKT-003","Feria del Agricultor Pavas","San Jose","San Jose","Pavas"),
    ("MKT-004","Feria Verde de Aranjuez","San Jose","San Jose","Aranjuez"),
    ("MKT-005","Feria del Agricultor Zapote","San Jose","San Jose","Zapote"),
    ("MKT-006","Feria del Agricultor Escazu","San Jose","Escazu","Escazu Centro"),
    ("MKT-007","Feria del Agricultor Guachipelin","San Jose","Escazu","Guachipelin"),
    ("MKT-008","Feria del Agricultor San Sebastian","San Jose","San Jose","San Sebastian"),
    ("MKT-009","Feria del Agricultor Alajuelita","San Jose","Alajuelita","Alajuelita"),
    ("MKT-010","Feria del Agricultor Belen","Heredia","Belen","San Antonio"),
    ("MKT-011","Feria del Agricultor Barva","Heredia","Barva","Barva Centro"),
    ("MKT-012","Feria del Agricultor Santo Domingo","Heredia","Santo Domingo","Santo Domingo"),
    ("MKT-013","Feria del Agricultor Alajuela Centro","Alajuela","Alajuela","Alajuela Centro"),
    ("MKT-014","Feria del Agricultor Cartago Centro","Cartago","Cartago","Oriental"),
    ("MKT-015","Feria del Agricultor Paraiso","Cartago","Paraiso","Paraiso Centro"),
]

# ---------- helpers ----------
def write_csv(path, header, rows):
    with open(path, "w", newline="", encoding="utf-8") as f:
        w = csv.writer(f)
        w.writerow(header)
        w.writerows(rows)

def escape_text(s: str) -> str:
    return s.replace("\n"," ").strip()

def cr_id():
    # 9 digits numeric. Simple realistic shape.
    return f"{random.randint(1,9)}{random.randint(0,9)}{random.randint(0,9)}{random.randint(0,9)}{random.randint(0,9)}{random.randint(0,9)}{random.randint(0,9)}{random.randint(0,9)}{random.randint(0,9)}"

def pick_market(province: str, district: str) -> str:
    if province not in GAM_PROVINCES:
        return "MKT-000"
    # exact district match
    for mid,_,prov,_,dist in MARKETS:
        if prov.lower()==province.lower() and dist.lower()==district.lower():
            return mid
    # same province fallback
    for mid,_,prov,_,_ in MARKETS:
        if prov.lower()==province.lower():
            return mid
    return "MKT-000"

def rand_username(first, last):
    base = f"{first}.{last}".lower()
    suffix = random.choice(["", str(random.randint(1,99))])
    return base + suffix

def rand_email(first, last):
    domains = ["gmail.com","outlook.com","hotmail.com","yahoo.com","icloud.com","proton.me","duck.com"]
    shapes = [
        "{f}{l}{n}@{d}",
        "{f}.{l}{n}@{d}",
        "{l}{f}{n}@{d}",
        "{f}_{l}@{d}",
        "{nick}{n}@{d}",
    ]
    nick_pool = ["tucampo","pura_vida","verdeagro","tierrat","haciendacr","fincasol","cr.market"]
    f = first.lower()
    l = last.lower()
    n = str(random.randint(1,999))
    d = random.choice(domains)
    nick = random.choice(nick_pool)
    shape = random.choice(shapes)
    return shape.format(f=f, l=l, n=n, d=d, nick=nick)

# ---------- load locations (optional validation) ----------
def load_locations(path):
    triples = set()
    if not os.path.exists(path):
        return triples
    with open(path, newline="", encoding="utf-8") as f:
        r = csv.DictReader(f)
        # expected header: ProvinceCode,ProvinceName,CantonCode,CantonName,DistrictCode,DistrictName
        for row in r:
            prov = row.get("ProvinceName","").strip()
            canton = row.get("CantonName","").strip()
            dist = row.get("DistrictName","").strip()
            if prov and canton and dist:
                triples.add((prov, canton, dist))
    return triples

# ---------- core generation ----------
def gen_markets():
    write_csv(MARKETS_CSV, ["MarketId","MarketName","Province","Canton","District"], MARKETS)

def gen_users(loc_triples):
    header = ["UserId","Username","Password","FirstName","FirstLastName","SecondLastName",
            "NationalId","Email","Phone","Address","Province","Canton","District","MarketId"]
    rows = []

    # fixed first two rows
    rows.append([
        "USR-"+"".join(random.choices(string.ascii_uppercase+string.digits,k=8)),
        "josue.villarreal","jv2025!","Josue","Villarreal","Saavedra","402420621",
        "josuevillarreal21@gmail.com","84919999",
        escape_text("Casa 124, La Esperanza, Bernardo Benavides"),
        "Heredia","Central","Bernardo Benavides", "MKT-001"
    ])
    rows.append([
        "USR-"+"".join(random.choices(string.ascii_uppercase+string.digits,k=8)),
        "luis.madriz","lm2001#","Luis Fernando","Madriz","Fonseca","208160834",
        "luisfermadriz2001@gmail.com","61300252",
        escape_text("Calle Principal 45, La Arena (parte norte)"),
        "Alajuela","Grecia","La Arena", "MKT-002"
    ])

    firsts = ["Maria","Carlos","Ana","Jose","Lucia","Andres","Elena","Daniel","Sofia","Javier","Laura","Pablo","Valeria","Diego","Camila","Marcos","Isabel","Rafael","Bianca","Tomas"]
    last_a = ["Lopez","Perez","Gomez","Vargas","Rojas","Hernandez","Castro","Navarro","Salas","Blanco","Alvarado","Campos","Mora","Acosta","Araya","Solano"]
    last_b = ["Jimenez","Rodriguez","Ramirez","Chacon","Herrera","Cortes","Zuniga","Sanchez","Viquez","Solis","Esquivel","Barrantes","Cordero","Quesada","Calderon","Leiva"]

    addr_samples = [
        "Calle 4, 100m sur de la iglesia",
        "Avenida 1, 25m oeste del parque",
        "Residencial Los Pinos, casa 23",
        "Entrada principal, 50m norte, porton negro",
        "Barrio Centro, frente a la escuela",
        "Urbanizacion La Pradera, torre B, apto 3",
        "Calle D, contiguo a la pulperia"
    ]

    # naive picks for canton/district if no official triples provided
    fallback = [
        ("San Jose","San Jose","Pavas"),
        ("San Jose","San Jose","Zapote"),
        ("San Jose","Escazu","Guachipelin"),
        ("Heredia","Heredia","Mercedes Norte"),
        ("Heredia","Barva","Barva Centro"),
        ("Alajuela","Grecia","La Arena"),
        ("Cartago","Cartago","Oriental"),
        ("Cartago","Paraiso","Paraiso Centro"),
        ("Puntarenas","Osa","Puerto Cortes"),
        ("Guanacaste","Nicoya","Nicoya Centro"),
        ("Limon","Pococi","Guapiles")
    ]

    def pick_geo():
        if loc_triples:
            prov,cant,dist = random.choice(list(loc_triples))
            return prov,cant,dist
        return random.choice(fallback)

    # generate more users
    for _ in range(28):  # total ~30
        fn = random.choice(firsts)
        ln1 = random.choice(last_a)
        ln2 = random.choice(last_b)
        prov,cant,dist = pick_geo()
        market = pick_market(prov, dist)
        username = rand_username(fn, ln1)
        email = rand_email(fn, ln1)
        phone = f"6{random.randint(1000000,9999999)}"
        addr = escape_text(random.choice(addr_samples))
        rows.append([
            "USR-"+"".join(random.choices(string.ascii_uppercase+string.digits,k=8)),
            username, "pw" + str(random.randint(1000,9999)),
            fn, ln1, ln2, cr_id(), email, phone, addr, prov, cant, dist, market
        ])

    write_csv(USERS_CSV, header, rows)

def gen_producers(count: int = 24, ratio_companies: float = 0.45):
    """
    Genera productores mixtos: personas fisicas y empresas.
    count: total de productores
    ratio_companies: fraccion de empresas (0..1)
    Escribe Producers/producers.csv con IsActive=true.
    """
    header = ["ProducerId","ProducerCode","NationalId","Name","Email","Phone","MarketId","UserId","IsActive"]

    firsts = ["Maria","Carlos","Ana","Jose","Lucia","Andres","Elena","Daniel","Sofia","Javier",
              "Laura","Pablo","Valeria","Diego","Camila","Marcos","Isabel","Rafael","Bianca","Tomas",
              "Gabriela","Fernando","Paola","Erick","Silvia","Adrian","Patricia","Hugo","Karla","Luis"]
    lasts  = ["Lopez","Perez","Gomez","Vargas","Rojas","Hernandez","Castro","Navarro","Salas","Blanco",
              "Alvarado","Campos","Mora","Acosta","Araya","Solano","Jimenez","Rodriguez","Ramirez","Chacon",
              "Herrera","Cortes","Zuniga","Sanchez","Viquez","Solis","Esquivel","Barrantes","Cordero","Quesada"]

    company_roots = ["Finca", "Agro", "Huerta", "Productores", "Cooperativa", "Lacteos", "Cafe", "Mieles",
                     "Hortalizas", "Frutales", "Granos", "Verduras", "Orgánicos", "Del Campo", "Sierra", "Montaña"]
    company_tails = ["La Pradera","El Roble","Grecia","Belen","Barva","Aranjuez","Paraiso","Escazu",
                     "San Sebastian","Mercedes","Turrialba","Orosi","Poas","Irazú","Volcanes","Talamanca"]

    domains = ["gmail.com","outlook.com","hotmail.com","yahoo.com","icloud.com","proton.me","duck.com"]

    # ids de mercados (preferencia por GAM)
    market_ids = [m[0] for m in MARKETS if m[0] != "MKT-000"]
    rng = random.Random(13579)

    def cr_national_id():
        # 9 digitos
        return str(rng.randint(1_000_00000, 9_999_99999))  # evita ceros iniciales

    def phone():
        # moviles CR comunes 6/7/8
        p0 = rng.choice(["6","7","8"])
        return p0 + f"{rng.randint(0000000,9999999):07d}"

    def make_person_name():
        return f"{rng.choice(firsts)} {rng.choice(lasts)} {rng.choice(lasts)}"

    def make_company_name():
        return f"{rng.choice(company_roots)} {rng.choice(company_tails)}"

    rows = []
    seen_codes = set()
    companies_target = int(round(count * ratio_companies))
    persons_target   = count - companies_target

    # personas fisicas
    for _ in range(persons_target):
        name = make_person_name()
        code = f"PDCR-{rng.randint(100,999)}"
        while code in seen_codes:
            code = f"PDCR-{rng.randint(100,999)}"
        seen_codes.add(code)

        mail = f"{name.split()[0].lower()}.{name.split()[1].lower()}{rng.randint(1,99)}@{rng.choice(domains)}"
        mid  = rng.choice(market_ids)
        rows.append([
            f"PR-{rng.randint(1,999):03d}", code, cr_national_id(), name, mail, phone(), mid, "", "true"
        ])

    # empresas
    for _ in range(companies_target):
        name = make_company_name()
        code = f"PDCR-{rng.randint(100,999)}"
        while code in seen_codes:
            code = f"PDCR-{rng.randint(100,999)}"
        seen_codes.add(code)

        slug = name.lower().replace(" ", "")
        mail = f"contacto@{slug[:10]}.cr" if rng.random() < 0.5 else f"ventas.{slug[:8]}@{rng.choice(domains)}"
        mid  = rng.choice(market_ids)
        rows.append([
            f"PR-{rng.randint(1,999):03d}", code, cr_national_id(), name, mail, phone(), mid, "", "true"
        ])

    write_csv(PRODUCERS_CSV, header, rows)


def gen_catalog(product_items):
    header = ["ProductCatalogId","Name","Unit","IsActive"]
    rows = []
    for idx,(name,unit) in enumerate(product_items, start=1):
        rows.append([f"CAT-{idx:04d}", name, unit, "true"])
    write_csv(CATALOG_CSV, header, rows)

def price_band(name: str):
    n = name.lower()
    if "banano" in n: return (300, 900)
    if "tomate" in n: return (600, 1500)
    if "cebolla" in n: return (600, 1800)
    if "papa" in n: return (600, 1600)
    if "huevo" in n: return (1800, 3000)
    if "queso" in n: return (2500, 5000)
    if "miel" in n: return (2500, 7000)
    if "cafe" in n: return (2500, 6000)
    return (800, 3000)

def gen_producer_products(product_items):
    # requires producers + catalog present
    if not (os.path.exists(PRODUCERS_CSV) and os.path.exists(CATALOG_CSV)):
        return
    with open(PRODUCERS_CSV, newline="", encoding="utf-8") as f:
        prod_rows = list(csv.DictReader(f))
    with open(CATALOG_CSV, newline="", encoding="utf-8") as f:
        cat_rows = list(csv.DictReader(f))
    producers = [r for r in prod_rows if r.get("IsActive","").lower()=="true"]
    catalog = [(r["ProductCatalogId"], r["Name"]) for r in cat_rows if r.get("IsActive","").lower()=="true"]

    header = ["ProducerProductId","ProducerId","ProductCatalogId","Price","Currency","VatRate",
            "Packaging","Grade","OrganicCert","HarvestDate","ExpiryDate",
            "MinOrder","MaxPerOrder","Stock","Status","CreatedAt","UpdatedAt","IsActive"]

    rng = random.Random(24680)
    pack = ["kg","unidad","manojo","bolsa 500g","bandeja 12u","docena"]
    grades = ["standard","premium","segunda"]
    uniq = set()
    rows = []

    # ensure each catalog item appears at least once
    for cid, name in catalog:
        p = rng.choice(producers)
        packaging = rng.choice(pack)
        grade = rng.choice(grades)
        key = (p["ProducerId"], cid, packaging, grade)
        if key in uniq:
            grade = "premium" if grade != "premium" else "standard"
            key = (p["ProducerId"], cid, packaging, grade)
        uniq.add(key)
        lo, hi = price_band(name)
        price = round(rng.uniform(lo, hi), 2)
        today = date.today()
        exp = today + timedelta(days=rng.randint(1, 30))
        rows.append([
            "PP-"+"".join(random.choices(string.ascii_uppercase+string.digits,k=10)),
            p["ProducerId"], cid, f"{price:.2f}","CRC","0.13",
            packaging, grade, "", today.isoformat(), exp.isoformat(),
            "", "", "", "available", today.isoformat(), today.isoformat(), "true"
        ])

    # extras
    for p in producers:
        for _ in range(rng.randint(2,4)):
            cid, name = rng.choice(catalog)
            packaging = rng.choice(pack)
            grade = rng.choice(grades)
            key = (p["ProducerId"], cid, packaging, grade)
            if key in uniq:
                grade = "premium" if grade != "premium" else "standard"
                key = (p["ProducerId"], cid, packaging, grade)
                if key in uniq:
                    continue
            uniq.add(key)
            lo, hi = price_band(name)
            price = round(rng.uniform(lo, hi), 2)
            today = date.today()
            exp = today + timedelta(days=rng.randint(1, 30))
            rows.append([
                "PP-"+"".join(random.choices(string.ascii_uppercase+string.digits,k=10)),
                p["ProducerId"], cid, f"{price:.2f}","CRC","0.13",
                packaging, grade, "", today.isoformat(), exp.isoformat(),
                "", "", "", "available", today.isoformat(), today.isoformat(), "true"
            ])

    write_csv(PPROD_CSV, header, rows)

def main():
    # 1) markets
    gen_markets()
    # 2) users (needs locations only for validation; if missing, uses fallback)
    loc_triples = load_locations(LOCATIONS_CSV)
    gen_users(loc_triples)
    # 3) producers
    gen_producers(count=30, ratio_companies=0.4)
    # 4) catalog (from external list at bottom)
    gen_catalog(PRODUCT_CATALOG)
    # 5) producer_products
    gen_producer_products(PRODUCT_CATALOG)
    print("CSV generation completed under:", DATA_DIR)

# ==== PRODUCT CATALOG (lista completa) ====

PRODUCT_CATALOG = [
    ("Tomate", "kg"),
    ("Cebolla amarilla", "kg"),
    ("Cebolla morada", "kg"),
    ("Papa blanca", "kg"),
    ("Papa roja", "kg"),
    ("Zanahoria", "kg"),
    ("Chayote", "kg"),
    ("Ayote sazon", "kg"),
    ("Chile dulce", "kg"),
    ("Pepino", "kg"),
    ("Lechuga romana", "unidad"),
    ("Lechuga americana", "unidad"),
    ("Repollo verde", "kg"),
    ("Repollo morado", "kg"),
    ("Culantro", "manojo"),
    ("Cilantro", "manojo"),
    ("Apio", "manojo"),
    ("Yuca", "kg"),
    ("Camote", "kg"),
    ("Platano verde", "kg"),
    ("Banano", "kg"),
    ("Limon mesino", "kg"),
    ("Naranja", "kg"),
    ("Mandarina", "kg"),
    ("Mango", "kg"),
    ("Papaya", "kg"),
    ("Pina", "kg"),
    ("Fresa", "kg"),
    ("Sandia", "kg"),
    ("Melon", "kg"),
    ("Aguacate", "unidad"),
    ("Guayaba", "kg"),
    ("Maracuya", "kg"),
    ("Hierbabuena", "manojo"),
    ("Albahaca", "manojo"),
    ("Romero", "manojo"),
    ("Tomillo", "manojo"),
    ("Oregano", "manojo"),
    ("Huevo AA", "docena"),
    ("Huevo A", "docena"),
    ("Queso fresco", "kg"),
    ("Queso tierno", "kg"),
    ("Queso mozzarella", "kg"),
    ("Leche entera", "litro"),
    ("Leche deslactosada", "litro"),
    ("Yogur natural", "litro"),
    ("Crema", "litro"),
    ("Mantequilla", "kg"),
    ("Miel de abeja", "kg"),
    ("Pan cuadrado", "unidad"),
    ("Pan baguette", "unidad"),
    ("Arroz blanco", "kg"),
    ("Frijol negro", "kg"),
    ("Frijol rojo", "kg"),
    ("Lenteja", "kg"),
    ("Garbanzos", "kg"),
    ("Azucar", "kg"),
    ("Sal yodada", "kg"),
    ("Cafe molido", "kg"),
    ("Cacao en polvo", "kg"),
    ("Aceite vegetal", "litro"),
    ("Aceite de oliva", "litro"),
    ("Harina de trigo", "kg"),
    ("Harina de maiz", "kg"),
    ("Tortillas de maiz", "paquete 500g"),
    ("Pasta corta", "kg"),
    ("Pasta larga", "kg"),
    ("Avena", "kg"),
    ("Granola", "kg"),
    ("Almendra", "kg"),
    ("Nuez", "kg"),
    ("Mani", "kg"),
    ("Salsa de tomate", "litro"),
    ("Salsa inglesa", "litro"),
    ("Mostaza", "litro"),
    ("Mayonesa", "litro"),
    ("Vinagre", "litro"),
    ("Atun en agua", "unidad"),
    ("Atun en aceite", "unidad"),
    ("Sardinas", "unidad"),
    ("Filete de tilapia", "kg"),
    ("Filete de corvina", "kg"),
    ("Pechuga de pollo", "kg"),
    ("Muslo de pollo", "kg"),
    ("Carne molida", "kg"),
    ("Bistec de res", "kg"),
    ("Cerdo lomo", "kg"),
    ("Chorizo", "kg"),
    ("Hongos champinon", "kg"),
    ("Hongos portobello", "kg"),
    ("Brocoli", "kg"),
    ("Coliflor", "kg"),
    ("Berenjena", "kg"),
    ("Remolacha", "kg"),
    ("Nabo", "kg"),
    ("Pepinillos", "kg"),
    ("Acelga", "manojo"),
    ("Espinaca", "manojo"),
    ("Uvas", "kg"),
    ("Pera", "kg"),
    ("Manzana", "kg"),
    ("Durazno", "kg"),
    ("Ciruela", "kg")
]

if __name__ == "__main__":
    main()
