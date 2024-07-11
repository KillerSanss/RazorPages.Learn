document.addEventListener('DOMContentLoaded', (event) => {
    const rows = document.querySelectorAll('tbody tr');
    const paginationButtons = document.querySelectorAll('.pagination a');
    const buttons = document.querySelectorAll('button');

    rows.forEach(row => {
        row.addEventListener('mouseover', () => {
            row.style.backgroundColor = 'lightgrey';
            row.style.cursor = 'pointer';
        });
        row.addEventListener('mouseout', () => {
            row.style.backgroundColor = '';
            row.style.cursor = 'default';
        });
    });

    paginationButtons.forEach(link => {
        link.addEventListener('mouseover', () => {
            link.style.backgroundColor = 'lightgrey';
            link.style.cursor = 'pointer';
        });
        link.addEventListener('mouseout', () => {
            link.style.backgroundColor = '';
            link.style.cursor = 'default';
        });
    });

    buttons.forEach(button => {
        button.addEventListener('mouseover', () => {
            button.style.backgroundColor = 'lightgrey';
            button.style.cursor = 'pointer';
        });
        button.addEventListener('mouseout', () => {
            button.style.backgroundColor = '';
            button.style.cursor = 'default';
        });
    });
});