// models/client.js
const pool = require('../services/db');

// Get all client info
const getAllClients = () => {
  return new Promise((resolve, reject) => {
    pool.query("SELECT * FROM client_info", (err, results) => {
      if (err) {
        console.error("Error fetching all clients", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Add a new client
const addClient = (client) => {
  const { lastName, firstName, middleName, contactNo, purok } = client;
  return new Promise((resolve, reject) => {
    const insertQuery = `
      INSERT INTO client_info(last_name, first_name, middle_name, contact_no, purok, month, year, date) 
      VALUES(?, ?, ?, ?, ?, MONTHNAME(CURRENT_DATE), YEAR(CURRENT_DATE), CURRENT_DATE)`;
    pool.query(insertQuery, [lastName, firstName, middleName, contactNo, purok], (err, results) => {
      if (err) {
        console.error("Error adding client:", err);
        reject(err);
      } else {
        resolve(results.insertId);
      }
    });
  });
};

// Delete billing info for a client
const deleteBillingInfo = (clientId) => {
  return new Promise((resolve, reject) => {
    const deleteQuery = "DELETE FROM billing_info WHERE client_id = ?";
    pool.query(deleteQuery, [clientId], (err, results) => {
      if (err) {
        console.error("Error deleting billing info:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Delete a client
const deleteClient = (clientId) => {
  return new Promise((resolve, reject) => {
    const deleteQuery = "DELETE FROM client_info WHERE client_id = ?";
    pool.query(deleteQuery, [clientId], (err, results) => {
      if (err) {
        console.error("Error deleting client:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Search clients by first or last name
const searchClients = (searchTerm) => {
  return new Promise((resolve, reject) => {
    const searchQuery = "SELECT * FROM client_info WHERE first_name LIKE ? OR last_name LIKE ?";
    const formattedSearchTerm = `%${searchTerm}%`;
    pool.query(searchQuery, [formattedSearchTerm, formattedSearchTerm], (err, results) => {
      if (err) {
        console.error("Error searching clients:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Update client info
const updateClient = (clientId, client) => {
  const { firstName, middleName, lastName, contactNo } = client;
  return new Promise((resolve, reject) => {
    const updateQuery = `
      UPDATE client_info 
      SET first_name = ?, middle_name = ?, last_name = ?, contact_no = ? 
      WHERE client_id = ?`;
    pool.query(updateQuery, [firstName, middleName, lastName, contactNo, clientId], (err, results) => {
      if (err) {
        console.error("Error updating client:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

module.exports = {
  getAllClients,
  addClient,
  deleteBillingInfo,
  deleteClient,
  searchClients,
  updateClient,
};
