import React from 'react'
import {Route} from 'react-router-dom'

import CategoryPage from './components/category/CategoryPage'
import FoodPage from './components/food/FoodPage'
import MenuPage from './components/menu/MenuPage'
import OrderPage from './components/order/OrderPage'
import TablePage from './components/table/TablePage'
import UserPage from './components/user/UserPage'
import Navigation from './components/navigation/Navigation'

import './App.css'

const App = () => (
  <div id="App" className="app">
  <Navigation />
  <Route exact path="/" component={MenuPage} />
  <Route path="/category" component={CategoryPage} />
  <Route path="/food" component={FoodPage} />
  <Route path="/order" component={OrderPage} />
  <Route path="/table" component={TablePage} />
  <Route path="/user" component={UserPage} />   
  </div>
)

export default App
