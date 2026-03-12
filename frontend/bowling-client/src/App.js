// App.js

import './App.css';
import Heading from './Heading';
import BowlerTable from './BowlerTable';

// Main application component that renders the heading and bowler table
function App() {
  return (
    <div className="app-container">
      <Heading />
      <BowlerTable />
    </div>
  );
}

// Export the App component as the default export
export default App;