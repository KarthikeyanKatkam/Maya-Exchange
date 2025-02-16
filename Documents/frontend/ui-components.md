# Maya Exchange UI Components

This document describes the key reusable UI components in the Maya Exchange frontend and their intended functionality.

---

## Component Overview

1. **Header**
   - Location: `src/components/Header.tsx`
   - Purpose: Displays the navigation bar, logo, and user-related actions like login/logout.

2. **Footer**
   - Location: `src/components/Footer.tsx`
   - Purpose: Provides links to important pages, social media, and company details.

3. **Button**
   - Location: `src/components/Button.tsx`
   - Purpose: A customizable button component used across the application.

4. **Input**
   - Location: `src/components/Input.tsx`
   - Purpose: A reusable input field for forms.

5. **Modal**
   - Location: `src/components/Modal.tsx`
   - Purpose: Displays overlay dialogs for actions like KYC verification and transaction confirmations.

6. **Card**
   - Location: `src/components/Card.tsx`
   - Purpose: Represents data visually (e.g., cryptocurrency prices, transaction summaries).

7. **Loader**
   - Location: `src/components/Loader.tsx`
   - Purpose: A loading spinner for asynchronous operations.

8. **Table**
   - Location: `src/components/Table.tsx`
   - Purpose: Displays tabular data (e.g., trade history, wallet balances).

---

## Component Guidelines

- **Styling**:
  - Follow a consistent theme defined in `src/styles/theme.ts`.
  - Use modular SCSS or styled-components for encapsulation.

- **State Management**:
  - Use `useState` or connect to the Redux store for state-driven behavior.

- **Testing**:
  - Ensure each component has unit tests in `src/__tests__/components/`.

---
