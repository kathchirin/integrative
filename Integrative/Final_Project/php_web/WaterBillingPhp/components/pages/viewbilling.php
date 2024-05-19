<?php

function bbilling()
{ ?>
    <div class="container-xxl flex-grow-1 container-p-y">
        <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Billing</span></h4>
        <div class="row">
        <div class="row">
            <div class="col-md-12">
                <label id="fullNameLabel"></label>
            </div>
        </div>
            <div class="col-md-12">
                <div class="card mb-4">
                    <hr class="my-0" />
                    <div class="card-body">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">ID</th>
                                    <th scope="col">Last Name</th>
                                    <th scope="col">First Name</th>
                                    <th scope="col">Contact Number</th>
                                    <th scope="col">Purok</th>
                                    <th scope="col">Actions</th>
                                </tr>
                            </thead>
                            <tbody id="clientTableBody">
                                <!-- Clients will be dynamically added here -->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Unpaid Bills</h5>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">Month</th>
                                    <th scope="col">Year</th>
                                    <th scope="col">Actions</th>
                                </tr>
                            </thead>
                            <tbody id="unpaidTableBody">
                                <!-- Unpaid billing info will be dynamically added here -->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Paid Bills</h5>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">Month</th>
                                    <th scope="col">Year</th>
                                    <th scope="col">Status</th>
                                </tr>
                            </thead>
                            <tbody id="paidTableBody">
                                <!-- Paid billing info will be dynamically added here -->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <!-- Label to display concatenated first name and last name -->
     

        <script>
            document.addEventListener('DOMContentLoaded', function() {
                const urlParams = new URLSearchParams(window.location.search);
                const clientId = urlParams.get('clientId');

                // Fetch and display all clients
                fetchClients();

                // Function to fetch clients
                function fetchClients() {
                    fetch('http://localhost:3000/api/clients')
                        .then(response => response.json())
                        .then(data => {
                            const clientTableBody = document.getElementById('clientTableBody');
                            clientTableBody.innerHTML = '';
                            data.forEach(client => {
                                const row = document.createElement('tr');
                                row.innerHTML = `
                                    <td>${client.client_id}</td>
                                    <td>${client.last_name}</td>
                                    <td>${client.first_name}</td>
                                    <td>${client.contact_no}</td>
                                    <td>${client.purok}</td>
                                    <td>
                                        <button class="btn btn-sm btn-danger view-bill-btn" data-client-id="${client.client_id}">View Bills</button>
                                    </td>
                                `;
                                clientTableBody.appendChild(row);
                            });
                        })
                        .catch(error => {
                            console.error('Error fetching clients:', error);
                        });
                }

                // Event listener for "View Bills" button clicks
                document.addEventListener('click', function(event) {
                    if (event.target.classList.contains('view-bill-btn')) {
                        const clientId = event.target.dataset.clientId;
                        fetchUnpaidBillingInfo(clientId);
                        fetchPaidBillingInfo(clientId);
                        
                        // Get the first name and last name
                        const firstName = event.target.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.textContent;
                        const lastName = event.target.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.textContent;
                        
                        // Concatenate and display in the label
                        document.getElementById('fullNameLabel').textContent = 'Name: ' + firstName + ' ' + lastName;

                        // Add a new bill record
                        addBillRecord();
                    }
                });

                // Function to fetch unpaid billing info
                function fetchUnpaidBillingInfo(clientId) {
                    fetch(`http://localhost:3000/bill/billing/unpaid/${clientId}`)
                        .then(response => response.json())
                        .then(data => {
                            const unpaidTableBody = document.getElementById('unpaidTableBody');
                            unpaidTableBody.innerHTML = '';
                            data.forEach(billing => {
                                const row = document.createElement('tr');
                                row.innerHTML = `
                                    <td>${billing.month}</td>
                                    <td>${billing.year}</td>
                                    <td><button class="btn btn-sm btn-primary pay-bill-btn" data-billing-id="${billing.billing_id}">Pay</button></td>
                                `;
                                unpaidTableBody.appendChild(row);
                            });
                        })
                        .catch(error => {
                            console.error('Error fetching unpaid billing info:', error);
                        });
                }

                // Function to fetch paid billing info
                function fetchPaidBillingInfo(clientId) {
                    fetch(`http://localhost:3000/bill/billing/paid/${clientId}`)
                        .then(response => response.json())
                        .then(data => {
                            const paidTableBody = document.getElementById('paidTableBody');
                            paidTableBody.innerHTML = '';
                            data.forEach(billing => {
                                const row = document.createElement('tr');
                                row.innerHTML = `
                                    <td>${billing.month}</td>
                                    <td>${billing.year}</td>
                                    <td>${billing.status}</td>
                                `;
                                paidTableBody.appendChild(row);
                            });
                        })
                        .catch(error => {
                            console.error('Error fetching paid billing info:', error);
                        });
                }

                // Function to handle bill payment
                document.addEventListener('click', function(event) {
                    if (event.target.classList.contains('pay-bill-btn')) {
                        const billingId = event.target.dataset.billingId;
                        payBill(billingId);
                    }
                });

                function payBill(billingId) {
                    fetch(`http://localhost:3000/bill/billing/pay/${billingId}`, {
                            method: 'PUT'
                        })
                        .then(response => response.json())
                        .then(data => {
                            fetchUnpaidBillingInfo(clientId);
                            fetchPaidBillingInfo(clientId);
                        })
                        .catch(error => {
                            console.error('Error paying bill:', error);
                        });
                }

                // Function to add a new bill record
                function addBillRecord() {
                    const currentDate = new Date();
                    const monthNames = ["January", "February", "March", "April", "May", "June",
                        "July", "August", "September", "October", "November", "December"
                    ];
                    const currentMonth = monthNames[currentDate.getMonth()];
                    const currentYear = currentDate.getFullYear();
                    const fullName = document.getElementById('fullNameLabel').textContent.replace('Name: ', '');

                    const bill = {
                        name: fullName,
                        date: currentDate.toISOString().split('T')[0],
                        month: currentMonth,
                        year: currentYear
                    };

                    fetch('http://localhost:3000/bill/billing/record', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify(bill)
                        })
                        .then(response => response.json())
                        .then(data => {
                            console.log('New bill record added:', data);
                        })
                        .catch(error => {
                            console.error('Error adding new bill record:', error);
                        });
                }
            });
        </script>
    </div>
<?php } ?>
