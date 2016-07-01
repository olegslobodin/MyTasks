var groups = [];

$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "http://localhost:62563/TaskGroups",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: onErrorCall
    });

    function onSuccess(response) {
        groups = response;
        showGroups();
    }

    function onErrorCall(response) {
        console.log(response);
    }
});

function showGroups() {
    for (group in groups) {
        var g = groups[group];
        console.log(g);

        $('.content').append(
            '<div id=\"group-' + g.ID + '\" class=\"col-md-4\">' +
                '<div class=\"row\">' +
                    '<h2>' +
                        g.Name +
                    '</h2>' +
                '</div>' +
            '</div>'
            );

        showTasks(g);

        showAddButon(g);
    }
}

function showTasks(group) {
    for (task in group.Tasks) {
        t = group.Tasks[task];
        console.log(t);

        $('#group-' + group.ID).append(
            '<div id=\"task-' + t.ID + '\" class=\"row\">' +
                t.Name +
            '</div>'
            );
    }
}

function showAddButon(group) {
    var lastGroup = $('.content').children().last();
    lastGroup.append(
        '<div class=\"row\">' +
            '<button id=\"add-to-' + group.ID + '\" type="button" class="btn btn-primary" data-toggle="modal" data-target="#addTaskModal" data-group-id=\"' + group.ID + '\" data-group-name=\"' + group.Name + '\">' +
                '+ New Task' +
            '</button>' +
        '</div>'
        );

    $('#add-to-' + group.ID)
        .click(function () {
            console.log('adding to group #' + group.ID);
        });
}

function addTask(groupId, taskName, taskContent) {
    
}

$('#addTaskModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var groupId = button.data('group-id');
    var groupName = button.data('group-name');
    var modal = $(this);
    modal.find('.modal-title').text('Add task for ' + groupName);

    $('#btn-save-task')
        .click(function () {
            var taskName = $('#task-name').val();
            var taskContent = $('#task-content').val();
            console.log('Saving task ' + taskName + ' with content: ' + taskContent + ' to group ' + groupName);
            addTask(groupId, taskName, taskContent);
        });
})