<?php 
function booking() { ?>
  <div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light"> Bill Records / </span>All Bill Records</h4>
    <div class="row">
      <div class="col-md-12">
        <div class="card mb-4">
          <hr class="my-0" />
          <div class="card-body">
            <table class="table">
              <thead>
                <tr>
                  <th scope="col">Name</th>
                  <th scope="col">Date</th>
                  <th scope="col">MONTH</th>
                  <th scope="col">YEAR</th>
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
  </div>

  <script>
    document.addEventListener('DOMContentLoaded', function() {
      // Fetch and display all clients
      fetchClients();
    });

    function fetchClients() {
      fetch('http://localhost:3000/rec/record')
        .then(response => response.json())
        .then(data => {
          const clientTableBody = document.getElementById('clientTableBody');
          clientTableBody.innerHTML = '';
          data.forEach(client => {
            const row = document.createElement('tr');
            const formattedDate = new Date(client.date).toLocaleDateString();  // Format date to only show date part
            row.innerHTML = `
              <td>${client.name}</td>
              <td>${formattedDate}</td>
              <td>${client.month}</td>
              <td>${client.year}</td>
            `;
            clientTableBody.appendChild(row);
          });
        })
        .catch(error => {
          console.error('Error fetching clients:', error);
        });
    }
  </script>
<?php } ?>
