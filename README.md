---
author: Lektion 3
date: MMMM dd, YYYY
paging: "%d / %d"
---

# Lektion 3

Hej och välkommen!

## Dagens agenda

1. Frågor och repetition
2. Repetition och mer om objekt-orienterad design
   1. Teori repetition
   2. Service-pattern, repository-pattern och dependency injection
   3. Kommandosystem (command-pattern)
3. Gruppövning med genomgång
4. Projektbygge
5. Eget arbete med handledning

---

# Objekt-orienterad design

- Kallas även objekt-orienterad programmering (OOP)
- Ett sätt att designa, strukturera och tänka kring kod
- Fokuserar på flexibilitet och användbarhet
- Bindande mellan data och funktionalitet
- Implementeras i och genom objekt & klasser
- Objekt skall ansvara för sig själva

---

# De fyra pelarna

- Principer och regler som definierar objekt-orienterad design
- Fokuserar på olika saker men kompletterar varandra

1. Abstraction
2. Encapsulation
3. Inheritance
4. Polymorphism

---

# Pelare 1: Abstraction

- Gör kod enkel att använda och förstå
- Generaliserar kod för flexibilitet
- Förenkla kod genom att “gömma” detaljer
- Förenkla kod genom att skapa ett enkelt API

---

# Pelare 2: Encapsulation

- Ett sätt att uppnå abstraction, den första pelaren
- Abstrahera kod genom att “gömma” data
- Låt objekt ansvara för sig själva genom att “gömma” data
- Förenkla kod genom att endast presentera API kod

---

# Pelare 3: Inheritance

- Återanvänd kod genom att ärva klasser
- Skapa ett enhetligt API genom arv
- Ärv metoder och fält
- Bildar ett slags hierarki med klasser

---

# Pelare 4: Polymorphism

- Bygger på inheritance, den tredje pelaren
- Ärv metoder och styr sedan implementationen
- Ökar kodens flexibilitet

---

# Gruppövning

Ni vill bygga en applikation med flera olika menyer. Implementera ett flexibelt menysystem med objekt-orienterad design.

Tips & hints:

- Skapa en basklass, alternativt ett interface, och flera subklasser
- Skapa en klass som håller koll på vilken meny som är aktiv
- Det skall vara smidigt att byta menyer

---

# Projektbygge: anteckningar

- Skapa användare
- Logga in & ut
- Skapa anteckning
  - Kategorisera anteckningar
  - Koppla till användare
- Radera anteckningar
- Uppdatera anteckningar
- Visa anteckningar
