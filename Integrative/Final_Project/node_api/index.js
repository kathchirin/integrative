// index.js
const express = require('express');
const clientRoutes = require('./routes/clientRouter');
const billingRoutes = require('./routes/billingRouter');
const recordRoutes = require('./routes/recordRouter');
const bodyParser = require('body-parser');
const cors = require('cors');

const app = express();
const port = 3000;

app.use(bodyParser.json());
app.use(cors());

// Corrected route setup
app.use('/api', clientRoutes);
app.use('/bill', billingRoutes);
app.use('/rec', recordRoutes);

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
