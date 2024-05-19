const recordModel = require("../models/record");

const getAllRecords = async (req, res) => {
  try {
    const records = await recordModel.getAllRecords();
    res.json(records);
  } catch (error) {
    console.error("Error in getAllRecords:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const searchRecords = async (req, res) => {
    try {
        const keyword = req.params.keyword; // Getting keyword from path parameter
        const records = await recordModel.searchRecords(keyword);
        res.json(records);
    } catch (error) {
        console.error("Error in searchRecords:", error);
        res.status(500).json({ error: "Internal Server Error" });
    }
};


module.exports = {
  getAllRecords,
  searchRecords,
};
