const delay = ms => new Promise(res => setTimeout(res, ms));

const disableCloseButton = async () => {
    document.getElementById("nukeCloseButton").disabled = true;
    for (let i = 5.00; i > 0; i -= 0.01) {
        document.getElementById("nukeCloseButton").innerHTML = "Nuking in " + i.toFixed(2) + " seconds...";
        await delay(10);
    }
    document.getElementById("nukeCloseButton").disabled = false;
    document.getElementById("nukeCloseButton").innerHTML = "Nuke";
}

const playExplosion = async () => {
    var audio = new Audio('/pages/mp3/explosion.mp3');
    audio.play();
    var nukeModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('explosionModal'));
    nukeModal.hide();
    document.body.style.display = "initial";
    document.body.style.display = "none";
    await delay(4000);
    document.body.style.display = "initial"; // Show the body again
}

const playExplosionHome = async () => {
    var audio = new Audio('/pages/mp3/explosion.mp3');
    audio.play();
    var nukeModal = bootstrap.Modal.getOrCreateInstance(document.getElementById('explosionModal'));
    nukeModal.hide();
    document.body.style.display = "initial";
    document.body.style.display = "none";
    await delay(4000);
    document.body.style.display = "initial"; // Show the body again
}
