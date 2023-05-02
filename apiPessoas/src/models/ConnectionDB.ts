import { Sequelize } from 'sequelize';

const sequelize = new Sequelize('chamadodb', 'root', 'fiscaltechbd', {
    host: 'localhost',
    dialect: 'mysql',
});

sequelize.authenticate().then(() => {
    console.log('Connection OK!');
}).catch(() => {
    console.log('Connection Error!')
});

export default sequelize;