import { createStore, applyMiddleware } from 'redux'
import { persistStore, persistReducer } from 'redux-persist'
import storage from 'redux-persist/lib/storage'
import { composeWithDevTools } from 'redux-devtools-extension'
import rootReducer from "./reducers"

const devEnv = process.env.NODE_ENV !== 'production'
const middleware = devEnv ? [require('redux-immutable-state-invariant').default()] : []

const persistConfig = {
  key: 'root',
  storage,
}

const persistedReducer = persistReducer(persistConfig, rootReducer)
let store = createStore(persistedReducer, composeWithDevTools(applyMiddleware(...middleware)))
let persistor = persistStore(store)

export {
  store,
  persistor
}