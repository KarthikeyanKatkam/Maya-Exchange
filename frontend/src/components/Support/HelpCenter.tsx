import React from 'react';
import './HelpCenter.css'; // Assuming you have a CSS file for styling

const HelpCenter: React.FC = () => {
  return (
    <div className="helpCenterContainer">
      <h1 className="helpCenterHeader">Help Center</h1>
      <p>If you have any questions or need assistance, please refer to the following resources:</p>
      <ul>
        <li><a href="/faq">Frequently Asked Questions</a></li>
        <li><a href="/contact">Contact Support</a></li>
        <li><a href="/guides">User Guides</a></li>
        <li><a href="/terms">Terms of Service</a></li>
        <li><a href="/privacy">Privacy Policy</a></li>
      </ul>
      <p>For KYC-related inquiries, please visit our <a href="/kyc">KYC Information</a> page.</p>
    </div>
  );
};

export default HelpCenter;
