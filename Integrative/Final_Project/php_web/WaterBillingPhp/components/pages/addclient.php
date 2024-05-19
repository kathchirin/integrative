<?php 
function addclient() { ?>
  <div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light"> Clients / </span>Add Clients</h4>
    <div class="row">
      <div class="col-md-12">
        <div class="card mb-4">
          <hr class="my-0" />
          <div class="card-body">
            <form id="clientForm">
              <div class="row">
                <div class="mb-3 col-md-6">
                  <label for="firstName" class="form-label">Last Name</label>
                  <input class="form-control" type="text" name="firstName" id="firstName" placeholder="Enter your First Name" autofocus required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="lastName" class="form-label">First Name</label>
                  <input class="form-control" type="text" name="lastName" id="lastName" placeholder="Enter your Last Name" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="middleName" class="form-label">Middle Name</label>
                  <input class="form-control" type="text" name="middleName" id="middleName" placeholder="Enter your Middle Name" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="purok" class="form-label">Purok</label>
                  <input class="form-control" type="text" name="purok" id="purok" placeholder="Enter purok" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="contact" class="form-label">Contact Number</label>
                  <input class="form-control" type="text" name="contact" id="contact" placeholder="Enter contact number" required />
                </div>
              </div>
              <div class="mt-2">
                <button type="submit" style="background-color: green;" class="btn btn-primary me-2">Add</button>
                <button type="reset" class="btn btn-outline-secondary">Cancel</button>
              </div>
            </form>
            <div id="responseMessage"></div>
          </div>
          <!-- /Account -->
        </div>
      </div>
    </div>
  </div>

  <script>
    document.getElementById('clientForm').addEventListener('submit', function(event) {
      event.preventDefault();

      const clientData = {
        firstName: document.getElementById('firstName').value,
        lastName: document.getElementById('lastName').value,
        middleName: document.getElementById('middleName').value,
        purok: document.getElementById('purok').value,
        contactNo: document.getElementById('contact').value
      };

      fetch('http://localhost:3000/api/client', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(clientData)
      })
      .then(response => response.json())
      .then(data => {
        alert('Client added successfully.');
        document.getElementById('clientForm').reset();
      })
      .catch(error => {
        console.error('Error:', error);
        alert('Error adding client.');
      });
    });
  </script>
<?php } ?>
