// controllers/clientController.js
const clientModel = require("../models/client");

const getAllClients = async (req, res) => {
  try {
    const clients = await clientModel.getAllClients();
    res.json(clients);
  } catch (error) {
    console.error("Error in getAllClients:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const addClient = async (req, res) => {
  try {
    const clientData = {
      lastName: req.body.lastName,
      firstName: req.body.firstName,
      middleName: req.body.middleName,
      contactNo: req.body.contactNo,
      purok: req.body.purok
    };
    const result = await clientModel.addClient(clientData);
    res.status(201).json({ message: "Client added successfully", clientId: result });
  } catch (error) {
    console.error("Error in addClient:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const deleteBillingInfo = async (req, res) => {
  try {
    const clientId = req.params.id;
    await clientModel.deleteBillingInfo(clientId);
    res.json({ message: "Billing info deleted successfully" });
  } catch (error) {
    console.error("Error in deleteBillingInfo:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const deleteClient = async (req, res) => {
  try {
    const clientId = req.params.id;
    await clientModel.deleteClient(clientId);
    res.json({ message: "Client deleted successfully" });
  } catch (error) {
    console.error("Error in deleteClient:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const searchClients = async (req, res) => {
  try {
    const searchTerm = req.query.term;
    const clients = await clientModel.searchClients(searchTerm);
    res.json(clients);
  } catch (error) {
    console.error("Error in searchClients:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

const updateClient = async (req, res) => {
  try {
    const clientId = req.params.id;
    const clientData = {
      firstName: req.body.firstName,
      middleName: req.body.middleName,
      lastName: req.body.lastName,
      contactNo: req.body.contactNo
    };
    await clientModel.updateClient(clientId, clientData);
    res.json({ message: "Client updated successfully" });
  } catch (error) {
    console.error("Error in updateClient:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
};

module.exports = {
  getAllClients,
  addClient,
  deleteBillingInfo,
  deleteClient,
  searchClients,
  updateClient,
};
