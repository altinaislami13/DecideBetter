# 📅 Sprint Plan – DecideWise

## 🧩 Sprint Overview
**Sprint Duration:** 2 Weeks  
**Start Date:** [Vendos datën]  
**End Date:** [Vendos datën]  
**Sprint Goal:** Implementimi i funksionalitetit bazë për vendimmarrje duke përdorur modelin Weighted Sum (MCDA), nga krijimi i një vendimi deri te shfaqja e rezultateve.

---

## 🎯 Sprint Objectives
- Ndërtimi i flow-it kryesor të aplikacionit
- Implementimi i algoritmit të llogaritjes (Weighted Sum Model)
- Krijimi i ndërfaqes për input dhe rezultate
- Sigurimi i një eksperience të thjeshtë dhe intuitive për përdoruesin

---

## 📌 Sprint Scope
Ky sprint fokusohet vetëm në **core functionality** të aplikacionit:
- Krijimi i një vendimi
- Shtimi i opsioneve
- Definimi i kritereve dhe peshave
- Vlerësimi i opsioneve
- Llogaritja dhe shfaqja e rezultateve

---

## 🗂️ User Stories

### US-01: Create Decision
**Si përdorues**, dua të krijoj një vendim të ri që të mund të krahasoj opsione.
- Shtim titulli
- Shtim opsionesh

### US-02: Define Criteria
**Si përdorues**, dua të përcaktoj kriteret dhe peshat.
- Shtim/Heqje kriteresh
- Peshat duhet të jenë 100% në total

### US-03: Score Options
**Si përdorues**, dua të vlerësoj opsionet për çdo kriter.
- Input 1–10
- Validim i inputeve

### US-04: Calculate Results
**Si përdorues**, dua që sistemi të llogarisë automatikisht rezultatin.
- Përdorimi i formulës Weighted Sum Model
- Përditësim në kohë reale

### US-05: View Results
**Si përdorues**, dua të shoh rezultatin final.
- Shfaqje e pikëve totale
- Renditja e opsioneve

---

## 🛠️ Sprint Backlog (Tasks)

### Frontend
- Ndërtimi i DecisionForm
- Krijimi i CriteriaBuilder
- Implementimi i ScoreMatrix
- Shfaqja e rezultateve

### Logic
- Implementimi i algoritmit të llogaritjes
- Validimi i peshave dhe inputeve

### State Management
- Menaxhimi i state me Zustand / Context API

---

## ⏱️ Sprint Timeline
| Faza | Koha |
|------|------|
| Planning | Dita 1 |
| Development | Dita 2–10 |
| Testing | Dita 11–12 |
| Final Review | Dita 13–14 |

---

## 📊 Definition of Done
- Të gjitha user stories janë implementuar
- Nuk ka gabime kritike
- Llogaritjet janë të sakta
- UI funksionon në desktop dhe mobile

---

## 🚧 Risks & Mitigation
- **Gabime në llogaritje** → Testim dhe validim
- **Kompleksitet i state** → Përdorim i Zustand
- **Mungesë kohe** → Fokus në core features

---

## 📌 Notes
- Fokus në funksionalitet bazë (MVP)
- Features të avancuara do shtohen në sprintet e ardhshme

---

✅ *Sprint plan i fokusuar në një inkrement funksional sipas metodologjisë Agile.*
