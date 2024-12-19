export const isEmpty = (value: string): boolean => {
    return !value || value.trim().length === 0;
  };
  
  // Validate email format
  export const isValidEmail = (email: string): boolean => {
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return emailRegex.test(email);
  };
  
  // Validate password (at least 8 characters, at least one letter and one number)
  export const isValidPassword = (password: string): boolean => {
    const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
    return passwordRegex.test(password);
  };
  
  // Example of usage for a registration form
  export const validateRegistrationForm = (email: string, password: string): string[] => {
    const errors: string[] = [];
  
    if (isEmpty(email)) {
      errors.push('Email is required');
    } else if (!isValidEmail(email)) {
      errors.push('Please enter a valid email address');
    }
  
    if (isEmpty(password)) {
      errors.push('Password is required');
    } else if (!isValidPassword(password)) {
      errors.push('Password must be at least 8 characters long and include at least one letter and one number');
    }
  
    return errors;
  };
  