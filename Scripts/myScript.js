function changePriority(taskId, action) {
    console.log("action: " + action);
    $.post("http://localhost:12345/Tasks/ChangePriority",
        {
            taskId: taskId,
            action: action
        },
        function (data, status) {
            if (data === "ok") {
                var task = $('#task-' + taskId);
                var priority = task.parent();
                priority.remove(task.selector);

                if (action === "Up") {
                    priority.next().append(task);
                } else {
                    priority.prev().append(task);
                }
            }
        });
}