function updateFlair() {
    bg = document.getElementById("flairColor").value;
    textColor = document.getElementById('flairTextColor').value;
    flair = document.getElementById('flairText').value;
    preview = document.getElementById('previewFlair');
    preview.className = `badge text-bg-${bg} text-${textColor}`;
    if (flair === "") {
        flair = "Flair";
    }
    preview.innerHTML = flair;
}