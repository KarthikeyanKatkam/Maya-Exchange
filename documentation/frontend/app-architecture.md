# Maya Exchange App Architecture

This document provides an overview of the architecture for the frontend of Maya Exchange.

---

## Key Design Principles

1. **Modularization**:
   - Separation of concerns between components, pages, and utilities.
   - Reusable and testable code.

2. **State Management**:
   - Centralized state using Redux Toolkit.
   - Local component state for UI-specific behavior.

3. **API Integration**:
   - Asynchronous calls managed with Redux Thunks.
   - Error handling and loading states for improved UX.

4. **Responsive Design**:
   - Mobile-first approach using media queries.
   - Cross-platform support for web and mobile via React Native.

---

## Directory Structure

