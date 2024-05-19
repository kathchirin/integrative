const clientModel = require("../models/billing");

const updateBillingInfo = async (req, res) => {
  try {
    const result = await clientModel.updateBillingInfo();
    res.status(200).json({ message: "Billing has been updated.", result });
  } catch (error) {
    console.error("Error in updateBillingInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const getAllBilling = async (req, res) => {
  try {
    const clients = await clientModel.getAllClients();
    res.json(clients);
  } catch (error) {
    console.error("Error in getAllClients:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const getPaidBillingInfo = async (req, res) => {
  try {
    const clientId = req.params.clientId;
    const billingInfo = await clientModel.getPaidBillingInfo(clientId);
    res.json(billingInfo);
  } catch (error) {
    console.error("Error in getPaidBillingInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const getUnpaidBillingInfo = async (req, res) => {
  try {
    const clientId = req.params.clientId;
    const billingInfo = await clientModel.getUnpaidBillingInfo(clientId);
    res.json(billingInfo);
  } catch (error) {
    console.error("Error in getUnpaidBillingInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const updateBillingStatus = async (req, res) => {
  try {
    const billingId = req.params.billingId;
    const result = await clientModel.updateBillingStatus(billingId);
    res.status(200).json({ message: "Paid", result });
  } catch (error) {
    console.error("Error in updateBillingStatus:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const addBillRecord = async (req, res) => {
  try {
    const result = await clientModel.addBillRecord(req.body);
    res.status(201).json({ message: "Bill record added successfully", billId: result });
  } catch (error) {
    console.error("Error in addBillRecord:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const getClient = async (req, res) => {
  try {
    const id = req.params.id;
    const client = await clientModel.getClientId(id);
    if (client) {
      res.json(client);
    } else {
      res.status(404).json({ message: "Client not found" });
    }
  } catch (error) {
    console.error("Error in getClientId:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const getUnpaidBillingCount = async (req, res) => {
  try {
    const clientId = req.params.clientId;
    const unpaidCount = await clientModel.getUnpaidBillingCount(clientId);
    res.json({ unpaidCount });
  } catch (error) {
    console.error("Error in getUnpaidBillingCount:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

module.exports = {
  updateBillingInfo,
  getAllBilling,
  getPaidBillingInfo,
  getUnpaidBillingInfo,
  updateBillingStatus,
  addBillRecord,
  getClient,
  getUnpaidBillingCount,
};
