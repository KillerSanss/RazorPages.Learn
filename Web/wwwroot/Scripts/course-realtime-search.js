const searchInput = document.querySelector('input[name="searchString"]');
const rows = document.querySelectorAll('tbody tr');
searchInput.addEventListener('input', () => {
    const filter = searchInput.value.toLowerCase();
    rows.forEach(row => {
        const name = row.children[0].textContent.toLowerCase();
        const description = row.children[1].textContent.toLowerCase();
        if (name.includes(filter) || description.includes(filter)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
});