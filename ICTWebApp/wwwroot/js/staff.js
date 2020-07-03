$(document).ready(function() {
    $('#tbldata').DataTable( {
        ajax: '/staff/getall',
        columns:[
            {"data":"staffID","width":"10%"},
            {"data":"staffName","width":"50%"},
            {
                "data":"staffID",
                "width":"30%",
                "render":function(data) {
                    return `
                            <a href="/staff/edit/${data}" class="btn btn-info">แก้ไข</a>
                            <a href="/staff/delete/${data}" class="btn btn-danger">ลบ</a>
                        `;
                }
            }
        ],
        width:"100%"
    } );
});