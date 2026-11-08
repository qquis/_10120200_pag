import { Router } from 'express'


const apis = Router();


import vipApi from './vipApi';
import bluesoftapi from './bluesoftApi';

apis.use("/vip", vipApi);
apis.use("/bluesoft", bluesoftapi);

export default apis;