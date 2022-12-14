window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message,'Operation successful', { timeOut: 5000 })
    }
    if (type === "warning") {
        toastr.warning(message,'Operation Failed', { timeOut: 5000 })
    }
    if (type === "error") {
        toastr.error(message,'Operation Failed', { timeOut: 5000 })
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire({
            title: 'Success Notification',
            text: message,
            icon: 'success',
            confirmButtonText: 'Cool'
        })
    }
    if (type === "error") {
        Swal.fire({
            title: 'Error Notification',
            text: message,
            icon: 'error',
            confirmButtonText: 'Cool'
        })
    }
}