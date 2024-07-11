const searchInput = document.querySelector('input[name="searchString"]');
const rows = document.querySelectorAll('tbody tr');
searchInput.addEventListener('input', () => {
    const filter = searchInput.value.toLowerCase();
    rows.forEach(row => {
        const firstName = row.children[0].textContent.toLowerCase();
        const surname = row.children[1].textContent.toLowerCase();
        const patronymic = row.children[2].textContent.toLowerCase();
        if (firstName.includes(filter) || surname.includes(filter) || patronymic.includes(filter)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
});