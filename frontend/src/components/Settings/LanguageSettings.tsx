import React, { useState } from 'react';
import './LanguageSettings.css'; // Assuming you have a CSS file for styling

const LanguageSettings: React.FC = () => {
  const [selectedLanguage, setSelectedLanguage] = useState<string>('en');

  const handleLanguageChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedLanguage(event.target.value);
    // Here you would typically also save the selected language to user preferences
  };

  return (
    <div className="languageSettingsContainer">
      <h1 className="languageSettingsHeader">Language Settings</h1>
      <label htmlFor="languageSelect">Select Language:</label>
      <select id="languageSelect" value={selectedLanguage} onChange={handleLanguageChange}>
        <option value="en">English</option>
        <option value="es">Spanish</option>
        <option value="fr">French</option>
        <option value="de">German</option>
        {/* Add more languages as needed */}
      </select>
      <p>Your selected language is: {selectedLanguage}</p>
    </div>
  );
};

export default LanguageSettings;
