const pool = require('../services/db');

// Insert new billing info if it meets the criteria
const updateBillingInfo = () => {
  return new Promise((resolve, reject) => {
    const query = `
      INSERT INTO billing_info (client_id, month, year, date, status) 
      SELECT client_info.client_id, MONTHNAME(CURRENT_DATE), YEAR(CURRENT_DATE), CURRENT_DATE, 'Unpaid' 
      FROM client_info 
      WHERE (SELECT MAX(date) FROM billing_info WHERE billing_info.client_id = client_info.client_id) < CURRENT_DATE 
      OR (SELECT MAX(date) FROM billing_info WHERE billing_info.client_id = client_info.client_id) IS NULL;
    `;
    pool.query(query, (err, results) => {
      if (err) {
        console.error("Error updating billing info:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Get all client info
const getAllClients = () => {
  return new Promise((resolve, reject) => {
    pool.query("SELECT client_id, CONCAT(first_name, ' ', last_name) AS Name, contact_no, purok FROM client_info", (err, results) => {
      if (err) {
        console.error("Error fetching all clients", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

const getUnpaidBillingCount = (clientId) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT COUNT(status) AS unpaidCount FROM billing_info WHERE client_id = ? AND status = 'Unpaid'";
    pool.query(query, [clientId], (err, results) => {
      if (err) {
        console.error("Error fetching unpaid billing count:", err);
        reject(err);
      } else {
        resolve(results[0].unpaidCount);
      }
    });
  });
};

const getClientId = (id) => {
  return new Promise((resolve, reject) => {
    pool.query('SELECT * FROM client_info WHERE client_id = ?', [id], (err, results) => {
      if (err) {
        console.error("Error fetching client by ID:", err);
        reject(err);
      } else {
        resolve(results[0]);
      }
    });
  });
};

// Get paid billing info by client_id
const getPaidBillingInfo = (clientId) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT billing_id, month, year, status FROM billing_info WHERE status = 'Paid' AND client_id = ?";
    pool.query(query, [clientId], (err, results) => {
      if (err) {
        console.error("Error fetching paid billing info:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Get unpaid billing info by client_id
const getUnpaidBillingInfo = (clientId) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT billing_id, month, year, status FROM billing_info WHERE status = 'Unpaid' AND client_id = ?";
    pool.query(query, [clientId], (err, results) => {
      if (err) {
        console.error("Error fetching unpaid billing info:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Update billing status to 'Paid'
const updateBillingStatus = (billingId) => {
  return new Promise((resolve, reject) => {
    const query = "UPDATE billing_info SET status = 'Paid' WHERE billing_id = ?";
    pool.query(query, [billingId], (err, results) => {
      if (err) {
        console.error("Error updating billing status:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Insert new bill record
const addBillRecord = (bill) => {
  return new Promise((resolve, reject) => {
    const { name, date, month, year } = bill;
    const query = "INSERT INTO bill_record (name, date, month, year) VALUES (?, ?, ?, ?)";
    pool.query(query, [name, date, month, year], (err, results) => {
      if (err) {
        console.error("Error adding bill record:", err);
        reject(err);
      } else {
        resolve(results.insertId);
      }
    });
  });
};


module.exports = {
  updateBillingInfo,
  getAllClients,
  getClientId,
  getPaidBillingInfo,
  getUnpaidBillingInfo,
  updateBillingStatus,
  addBillRecord,
  getUnpaidBillingCount,
};
