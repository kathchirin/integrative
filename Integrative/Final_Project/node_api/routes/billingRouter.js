const express = require('express');
const router = express.Router();
const billingController = require('../controllers/billingController');

router.post('/billing/update', billingController.updateBillingInfo);
router.get('/clients', billingController.getAllBilling);
router.get('/billing/paid/:clientId', billingController.getPaidBillingInfo);
router.put('/billing/pay/:billingId', billingController.updateBillingStatus);
router.post('/billing/record', billingController.addBillRecord);
router.get('/client/:id', billingController.getClient);
router.get('/billing/unpaid/:clientId', billingController.getUnpaidBillingInfo);
router.get('/billing/unpaid/count/:clientId', billingController.getUnpaidBillingCount);

module.exports = router;
