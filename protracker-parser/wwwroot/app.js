document.getElementById('sendBtn').addEventListener('click', async () => {
    const inputField = document.getElementById('userInput');
    const responseArea = document.getElementById('responseArea');
    const text = inputField.value;

    if (!text) {
        responseArea.innerText = "Input cannot be empty";
        return;
    }

    responseArea.innerText = "Processing...";

    try {
        const response = await fetch('/api/parser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ InputText: text })
        });

        if (response.ok) {
            const data = await response.text();
            responseArea.innerText = data;
        } else {
            responseArea.innerText = "Server Error: " + response.status;
        }
    } catch (error) {
        responseArea.innerText = "Connection Failed: " + error.message;
    }
});