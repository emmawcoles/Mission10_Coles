import { useEffect, useState } from 'react';

// BowlerTable component that fetches and displays a list of bowlers in a table format
function BowlerTable() {
  const [bowlers, setBowlers] = useState([]);

  // Fetch bowlers from the API when the component mounts
  useEffect(() => {
    fetch('http://localhost:5021/Bowlers')
      .then((response) => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then((data) => {
        console.log(data);
        setBowlers(data);
      })
      .catch((error) => console.error('Error fetching bowlers:', error));
  }, []);

  // Render the table of bowlers
  return (
    <div className="table-container">
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Team</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((b) => (
            <tr key={b.bowlerId}>
              <td>
                {b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}
              </td>
              <td>
                <span className="team-badge">{b.teamName}</span>
              </td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

// Export the BowlerTable component as the default export
export default BowlerTable;