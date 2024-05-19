<?php 

function client() { ?>
  <div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light"> Clients / </span>All Clients</h4>
    <div class="row">
      <div class="col-md-12">
        <div class="card mb-4">
          <hr class="my-0" />
          <div class="card-body">
            <table class="table">
              <thead>
                <tr>
                  <th scope="col">First Name</th>
                  <th scope="col">Last Name</th>
                  <th scope="col">Middle Name</th>
                  <th scope="col">Purok</th>
                  <th scope="col">Contact Number</th>
                  <th scope="col">Date</th>
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

    <!-- Edit Client Modal -->
    <div class="modal fade" id="editClientModal" tabindex="-1" aria-labelledby="editClientModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="editClientModalLabel">Edit Client</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <form id="editClientForm">
              <div class="mb-3">
                <label for="editFirstName" class="form-label">First Name</label>
                <input type="text" class="form-control" id="editFirstName" required>
              </div>
              <div class="mb-3">
                <label for="editLastName" class="form-label">Last Name</label>
                <input type="text" class="form-control" id="editLastName" required>
              </div>
              <div class="mb-3">
                <label for="editMiddleName" class="form-label">Middle Name</label>
                <input type="text" class="form-control" id="editMiddleName" required>
              </div>
              <div class="mb-3">
                <label for="editContact" class="form-label">Contact Number</label>
                <input type="text" class="form-control" id="editContact" required>
              </div>
              <input type="hidden" id="editClientId">
              <button type="submit" class="btn btn-primary">Save changes</button>
            </form>
          </div>
        </div>
      </div>
    </div>

    <script>
      document.addEventListener('DOMContentLoaded', function() {
        // Fetch and display all clients
        fetchClients();

        // Handle edit client form submission
        document.getElementById('editClientForm').addEventListener('submit', function(event) {
          event.preventDefault();
          const clientId = document.getElementById('editClientId').value;
          const clientData = {
            firstName: document.getElementById('editFirstName').value,
            lastName: document.getElementById('editLastName').value,
            middleName: document.getElementById('editMiddleName').value,
            contactNo: document.getElementById('editContact').value
          };
          updateClient(clientId, clientData);
        });

        // Add event listener to "Edit" buttons
        const editButtons = document.querySelectorAll('.edit-client-btn');
        editButtons.forEach(button => {
          button.addEventListener('click', function(event) {
            const clientId = event.target.dataset.clientId;
            editClient(clientId);
          });
        });
      });

      function fetchClients() {
        fetch('http://localhost:3000/api/clients')
          .then(response => response.json())
          .then(data => {
            const clientTableBody = document.getElementById('clientTableBody');
            clientTableBody.innerHTML = '';
            data.forEach(client => {
              const row = document.createElement('tr');
              const formattedDate = new Date(client.date).toLocaleDateString();  // Format date to only show date part
              row.innerHTML = `
                <td>${client.first_name}</td>
                <td>${client.last_name}</td>
                <td>${client.middle_name}</td>
                <td>${client.purok}</td>
                <td>${client.contact_no}</td>
                <td>${formattedDate}</td>
                <td>
                  <button class="btn btn-sm btn-danger" onclick="deleteClient(${client.client_id})">Delete</button>
                </td>
              `;
              clientTableBody.appendChild(row);
            });
          })
          .catch(error => {
            console.error('Error fetching clients:', error);
          });
      }

      function deleteClient(id) {
        if (confirm('Are you sure you want to delete this client?')) {
          fetch(`http://localhost:3000/api/client/${id}`, {
            method: 'DELETE'
          })
          .then(response => response.json())
          .then(data => {
            alert('Client deleted successfully.');
            fetchClients();  // Refresh the client list
          })
          .catch(error => {
            console.error('Error deleting client:', error);
            alert('Error deleting client.');
          });
        }
      }

      function editClient(id) {
        fetch(`http://localhost:3000/api/client/${id}`)
          .then(response => response.json())
          .then(client => {
            document.getElementById('editClientId').value = client.client_id;
            document.getElementById('editFirstName').value = client.first_name;
            document.getElementById('editLastName').value = client.last_name;
            document.getElementById('editMiddleName').value = client.middle_name;
            document.getElementById('editContact').value = client.contact
            _no;
            const editClientModal = new bootstrap.Modal(document.getElementById('editClientModal'));
            editClientModal.show();
          })
          .catch(error => {
            console.error('Error fetching client:', error);
          });
      }

      function updateClient(clientId, clientData) {
        fetch(`http://localhost:3000/api/client/${clientId}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(clientData)
        })
        .then(response => response.json())
        .then(data => {
          alert('Client updated successfully.');
          fetchClients();  // Refresh the client list
          const editClientModal = bootstrap.Modal.getInstance(document.getElementById('editClientModal'));
          editClientModal.hide();
        })
        .catch(error => {
          console.error('Error updating client:', error);
          alert('Error updating client.');
        });
      }
    </script>
<?php } ?>
