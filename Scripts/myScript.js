function changePriority(taskId, action) {
    console.log("action: " + action);
    $.post("http://localhost:12345/Tasks/ChangePriority",
        {
            taskId: taskId,
            action: action
        },
        function (data, status) {
            $('#partial-' + data.fromId).html(data.fromPartial);
            $('#partial-' + data.toId).html(data.toPartial);
        });
}

function removeTask(priorityId, taskId) {
    $('#priority-' + priorityId + ' #task-' + taskId).remove();
}

function getNewPartialId(priorityId, action) {
    var currentPartial = $('#priority-' + priorityId).parent();
    if (action === 'Up')
        return currentPartial.next().attr('id');
    else
        return currentPartial.prev().attr('id');
}