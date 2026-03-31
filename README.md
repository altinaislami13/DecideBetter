# 🎯 DecideWise

> **Make big decisions with confidence — not guesswork.**

DecideWise is a multi-criteria decision analysis (MCDA) web application that helps you compare options logically, visually, and objectively. Whether you're choosing a job offer, a university, a laptop, or a city to live in — DecideWise turns overwhelming choices into clear, data-driven decisions.

---

## ✨ Features

- **Multi-Criteria Decision System** — Define any number of criteria tailored to your decision
- **Custom Weight Assignment** — Assign percentage weights to each criterion based on your priorities
- **Weighted Scoring Algorithm** — Each option is scored using a transparent weighted average formula
- **Visual Comparison Charts** — Bar charts, radar charts, and score breakdowns for instant insight
- **Saved Decisions** — Store and revisit past decisions (localStorage / backend)
- **Decision History** — Track how your thinking evolves over time
- **Responsive UI** — Works seamlessly on desktop and mobile

---

## 🧠 How It Works

DecideWise uses the **Weighted Sum Model (WSM)** — a classic multi-criteria decision analysis algorithm:

```
Score(option) = Σ (weight_i × score_i)
```

### Example

| Criteria        | Weight | Job A Score | Job B Score |
|----------------|--------|-------------|-------------|
| Salary          | 40%    | 8           | 6           |
| Location        | 20%    | 7           | 9           |
| Work-Life Balance | 15%  | 6           | 8           |
| Growth          | 25%    | 9           | 7           |

**Job A Total:** `(0.40×8) + (0.20×7) + (0.15×6) + (0.25×9)` = **7.75** ✅  
**Job B Total:** `(0.40×6) + (0.20×9) + (0.15×8) + (0.25×7)` = **7.15**

> DecideWise recommends **Job A** 🎉

---

## 🛠️ Tech Stack

| Layer       | Technology                    |
|-------------|-------------------------------|
| Frontend    | React + TypeScript            |
| Styling     | Tailwind CSS                  |
| Charts      | Recharts / Chart.js           |
| State       | Zustand / Context API         |
| Storage     | localStorage + optional REST API |
| Backend (opt) | Node.js + Express + PostgreSQL |

---

## 🚀 Getting Started

### Prerequisites

- Node.js >= 18
- npm or yarn

### Installation

```bash
# Clone the repository
git clone https://github.com/yourusername/decidewise.git
cd decidewise

# Install dependencies
npm install

# Start development server
npm run dev
```

### Build for Production

```bash
npm run build
npm run preview
```

---

## 📁 Project Structure

```
decidewise/
├── public/
│   └── favicon.ico
├── src/
│   ├── components/
│   │   ├── DecisionForm/
│   │   ├── CriteriaBuilder/
│   │   ├── ScoreMatrix/
│   │   ├── ResultsChart/
│   │   └── SavedDecisions/
│   ├── hooks/
│   │   └── useDecision.ts
│   ├── utils/
│   │   └── scoringAlgorithm.ts
│   ├── store/
│   │   └── decisionStore.ts
│   ├── types/
│   │   └── index.ts
│   ├── App.tsx
│   └── main.tsx
├── .gitignore
├── README.md
├── package.json
├── tailwind.config.js
├── tsconfig.json
└── vite.config.ts
```

---

## 📊 Portfolio Value

This project demonstrates:

- ✅ **Algorithm Design** — Weighted scoring & MCDA implementation
- ✅ **Data Modeling** — Flexible schema for options, criteria, and weights
- ✅ **Analytics Dashboard** — Interactive charts and visual comparisons
- ✅ **State Management** — Complex, nested application state
- ✅ **UX Thinking** — Guiding users through a structured decision process
- ✅ **Persistence Layer** — Saving and loading decisions across sessions

---

## 🗺️ Roadmap

- [ ] AI-assisted criteria suggestions
- [ ] Team/collaborative decisions
- [ ] Export to PDF report
- [ ] Decision comparison history
- [ ] Mobile app (React Native)
- [ ] Dark / Light mode

---

## 🤝 Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you'd like to change.

1. Fork the repo
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## 📄 License

MIT License — see [LICENSE](LICENSE) for details.

---

> Built with ❤️ to eliminate decision fatigue.
