const pool = require('../services/db');

const getAllRecords = () => {
  return new Promise((resolve, reject) => {
    pool.query("SELECT * FROM bill_record", (err, results) => {
      if (err) {
        console.error("Error fetching all records:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

const searchRecords = (keyword) => {
    return new Promise((resolve, reject) => {
        const query = `
            SELECT * FROM bill_record 
            WHERE name LIKE ? OR date = ? OR month = ? OR year = ?
        `;
        const searchKeyword = `%${keyword}%`; // Adding wildcard for partial matching
        pool.query(query, [searchKeyword, keyword, keyword, keyword], (err, results) => {
            if (err) {
                console.error("Error searching records:", err);
                reject(err);
            } else {
                resolve(results);
            }
        });
    });
};




  

module.exports = {
  getAllRecords,
  searchRecords,
};
