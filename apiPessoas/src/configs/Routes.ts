import { Router } from 'express';
import { PessoaController } from '../controllers/Pessoa.controller';
import { EnderecoController } from '../controllers/Endereco.controller';

const router: Router = Router();

/**
 * @swagger
 * /get:
 *   get:
 *     description: Buscar todas as pessoas
 *     responses:
 *       200:
 *         description: Sucesso
 */
router.get('/get', new PessoaController().listar);

router.get('/BuscarPorId/:idPessoa', new PessoaController().Buscar);

router.post('/newPessoa', new PessoaController().cadastrar);

router.put('/atualizarPessoa', new PessoaController().atualizar);

router.delete('/deletarPessoa/:idPessoa', new PessoaController().deletar);

router.get('/getApi/:cep', new EnderecoController().getApi)

export { router }