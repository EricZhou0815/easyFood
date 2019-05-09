import React,{Component} from 'react'
import {connect} from 'react-redux'
import {cacheAllFoods} from '../../redux/actions/foodActions'

class FoodPage extends Component{
  constructor(props){
    super(props)
    this.state={
      foods:[]
    }
  }

  componentDidMount=async()=>{
    const food={'Name':'','Price':20,'PictureUrl':'','Summary':'','Description':''}
    cacheAllFoods(food)
  }

  render(){
    return (
      <div className="food-page">
      Food
    </div>
    )
  }
}

const actionCreators={
  cacheAllFoods
}

const mapStateToProps=state=>({
  foods:state.food.foods
})


export default connect(mapStateToProps,actionCreators)(FoodPage);