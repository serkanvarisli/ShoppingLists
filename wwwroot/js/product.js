
// Edit Product Page
const editproduct = document.getElementById('editproduct');
const saveproduct = document.getElementById('saveproduct');
const myInput1 = document.getElementById('tb1');
const myInput2 = document.getElementById('tb2');
const myInput3 = document.getElementById('tb3');
const myInput4 = document.getElementById('tb4');


editproduct.addEventListener('click', function () {
    myInput1.readOnly = true;
    myInput2.readOnly = false;
    myInput3.readOnly = false;
    myInput4.readOnly = false;
    saveproduct.hidden = false;
    editproduct.hidden = true;
});

saveproduct.addEventListener('click', function () {
    myInput1.readOnly = true;
    myInput2.readOnly = true;
    myInput3.readOnly = true;
    myInput4.readOnly = true;
    saveproduct.hidden = true;
    editproduct.hidden = false;

});
