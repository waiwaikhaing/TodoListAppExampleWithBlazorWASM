
function showAlert(message) {
    alert(message);
}

function ToggleText(data) {
    var tasks = document.querySelectorAll(".task");
    for (var i = 0; i < tasks.length; i++) {
        if (tasks[i].innerText == data) {
            tasks[i].classList.toggle('completed');
        }
    }
}