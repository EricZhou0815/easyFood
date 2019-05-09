import {createStore,applyMiddleware} from 'redux'
import { composeWithDevTools } from 'redux-devtools-extension'
import rootReducer from './reducers'

const devEnv = process.env.NODE_ENV !== 'production'
const middleware = devEnv ? [require('redux-immutable-state-invariant').default()] : []

const store = createStore(rootReducer, composeWithDevTools(applyMiddleware(...middleware)))

export default store