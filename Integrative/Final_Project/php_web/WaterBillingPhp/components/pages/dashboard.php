<?php 
function dashboard(){ ?>
    <div class="container-xxl flex-grow-1 container-p-y">
        <h2 class="fw-bold py-3 mb-4"><span class="text-muted fw-light"></span>DASHBOARD</h2>
        <div class="container">
            <div class="full-box" id="officialsBox">

                <h3>OFFICIALS OF BARANGAY BASAK</h3>
                <div id="officialsText">
                    <p><strong>Barangay Captain:</strong><br>Renato B. Calas</p> <br>
                    <p><strong>Barangay Kagawad:</strong><br>Noel M. Buling</p>
                    <p><strong>Barangay Kagawad:</strong><br>Dario J. Bulabog </p>
                    <p><strong>Barangay Kagawad:</strong><br>Cynthia A. Baterna</p>
                    <p><strong>Barangay Kagawad:</strong><br>Rotchelyn S. Mendoza</p>
                    <p><strong>Barangay Kagawad:</strong><br>Brandy A. Eltagonde</p>
                    <p><strong>Barangay Kagawad:</strong><br>Ronel L. Seno</p>
                    <p><strong>Barangay Kagawad:</strong><br>Aurea S. Medilo</p>
                </div>
            </div>
            <div class="box-container">
                <div class="box" id="missionBox">
                    <h3>Mission</h3>
                    <p id="missionText"> Ang Barangay Basak mahimong sentro sa agrikultura, hapsay ang kinaiyahan diin ang mga 
                        lumulupyo, himsog ug mahigugmaon sa mga maligdong nga pamunoan.</p>
                </div>
                <div class="box" id="visionBox">
                    <h3>Vision</h3>
                    <p id="visionText"> Ang Barangay Basak maoy katilingbanon nga mauswagon, malamboon sa agrikultura hapsay ang 
                        kinaiyahan diin ang mga lumulupyo malipayon, himsog ug mahigugmaon sa Dios kompleto sa pasilidad sa mga 
                        namuno nga matinud-anon sa Dios, ug makaligon sa katalagnan.</p>
                </div>
                <div class="box" id="coreValuesBox">
                    <h3>Core Values</h3>
                    <p id="coreValuesText"><b>Paghiusa</b> - Kinahanglan ang pagpakig-uban ug pagkahiusa sa sulod sa barangay aron mapreserba ang kalinaw ug pag-amoma sa isigkaingon.<br>
<b>Pagtabangay</b> - Ang pagtinabangay ug pagbuligay sa usag-usa atol sa mga kahimtang sa kinahanglanon nagapalig-on sa paghiusa sa barangay.<br>
<b>Pag-alalay</b> - Ang paghatag ug tabang o suporta sa kauban, labi na sa mga proyekto nga makatabang sa kaayuhan sa barangay, usa ka batak nga halad sa komunidad.<br>
<b>Pag-respeto</b> - Ang pagtahod ug pagdawat sa matag miyembro sa barangay, bisan unsa ang ilang posisyon o pagtuo, kinahanglan aron mapreserba ang kalinaw ug hilit nga relasyon.<br>
<b>Pag-ampo</b> - Ang pagtuo sa Diyos ug pag-ampo alang sa kaayuhan sa barangay ug sa matag indibidwal nagahatag og kusog ug gahom ngadto sa mga katawhan.</p>
                </div>
            </div>
        </div>
    </div>

    <style>
        .container {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
            margin-top: 50px;
        }
        .full-box {
            width: calc(40% - 20px);
            background-color: #f0f0f0;
            border: 2px solid #ccc;
            text-align: center;
            font-size: 18px;
            margin-bottom: 20px;
            padding: 20px;
            box-sizing: border-box;
        }

        .box-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: flex-end; /* Adjusted to push boxes to the right */
            width: 60%; /* Adjusted to fit the boxes */
        }

        .box {
            width: calc(130% - 60px); /* Adjusted to fit two boxes in a row */
            background-color: #f0f0f0;
            border: 2px solid #ccc;
            text-align: center;
            font-size: 18px;
            margin-bottom: 20px;
            padding: 20px;
            box-sizing: border-box;
        }

        #officialsText {
            font-weight: bold;
            text-align: left;
        }

        .content {
          text-align: left;
        }
    </style>
</body>
<?php } ?>
