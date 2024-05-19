// routes/clientRoutes.js
const express = require('express');
const router = express.Router();
const clientController = require('../controllers/clientController');

router.get('/clients', clientController.getAllClients);
router.post('/client', clientController.addClient);
router.delete('/billing/:id', clientController.deleteBillingInfo);
router.delete('/client/:id', clientController.deleteClient);
router.get('/clients/search', clientController.searchClients);
router.put('/client/:id', clientController.updateClient);

module.exports = router;
