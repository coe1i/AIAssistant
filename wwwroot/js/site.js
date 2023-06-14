window.onload = function () {
    fetch('/Home/Visit')
        .then(response => response.json())
        .then(data => {
            document.getElementById('visitCounter').textContent = data.visits;
        });
}
