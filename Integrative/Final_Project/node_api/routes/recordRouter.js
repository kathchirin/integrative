const express = require('express');
const router = express.Router();
const recordController = require('../controllers/recordController');

// GET all records
router.get('/record', recordController.getAllRecords);

// GET records by search keyword
router.get('/record/search/:keyword', recordController.searchRecords);

module.exports = router;
