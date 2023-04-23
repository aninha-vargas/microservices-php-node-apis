const express = require('express');

const app = express();
const PORT = 8001;

app.use(express.json());

app.listen(PORT, () => {
    console.clear();
    console.log(`Aplicação PESSOAS rodando na porta ${PORT}`);
})