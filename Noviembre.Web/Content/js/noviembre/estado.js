function eliminar(id) {
    if (confirm("¿Estás seguro que desea eliminar el resgistro?")) {
        var url = "/Estado/Eliminar/" + id;
        window.location.href = url;
    }
} 