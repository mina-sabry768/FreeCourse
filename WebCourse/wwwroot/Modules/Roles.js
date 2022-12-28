$(document).ready(function () {
    $('#tableRole').DataTable({
        "autoWidth": false,
        "responsive": true
    });
    
});

function Delete(id) {
    Swal.fire({
        title: 'are you Sur?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        lbcancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/Accounts/DeleteRole?Id=${id}`;
            Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
        }
    })
}


Edit = (id, name) => {

    document.getElementById("title").innerHTML = 'Edit Role';
    document.getElementById("btnSave").value = 'Edit';
    document.getElementById("roleId").value = id;
    document.getElementById("roleName").value = name;

}

Rest = () => {
    document.getElementById("title").innerHTML = 'Add New Role';
    document.getElementById("btnSave").value = 'Save';
    document.getElementById("roleId").value = "";
    document.getElementById("roleName").value = "";

}