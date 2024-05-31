const intruderAlert = async () => {
    var bg = document.getElementById("mainContainer");
    await delay(500);
    bg.classList.replace("bg-danger", "bg-primary");
    await delay(500);
    bg.classList.replace("bg-primary", "bg-danger");
    await delay(500);
    bg.classList.replace("bg-danger", "bg-primary");
    await delay(500);
    bg.classList.replace("bg-primary", "bg-danger");
    await delay(500);
    window.location.href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
}

window.onload = intruderAlert;