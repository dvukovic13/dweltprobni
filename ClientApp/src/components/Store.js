import React, { Component } from "react";
import './Store.css'
import noImage from '../assets/noImage.jpg';

export class Store extends Component{
    static displayName = Store.name;

    constructor(props){
        super(props);
        this.state = {items:[], loading: true}
    }


    componentDidMount(){
        this.getStoreItems();
        
    }

    static renderStoreItems(items){
        return(
            <div className="itemsList">
                {items.map(item => 
                    <div>
                        <p key={item.Id}>key</p>
                        <h3>{item.name}</h3>
                        <img src={item.image==null ? noImage:item.image} style={{width:'200px'}}></img>
                        <h4>{item.type}</h4>
                        <button>Dodaj u korpu</button>
                    </div>
                    )}
            </div>

        /*<table className='tabela' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Tip</th>
                    <th>Ime</th>
                    <th>Cijena</th>
                </tr>
            </thead>
            <tbody>
            {items.map(item =>
                <tr key={item.id}>
                <td>{item.type}</td>
                <td>{item.name}</td>
                <td>{item.price}</td>
                </tr>
            )}
            </tbody>
      </table>*/
        );
    }

    render(){
        let isLoading = this.state.loading;
        let content = isLoading ? <p>Loading...</p> : Store.renderStoreItems(this.state.items)

        return(
            <div style={{width:'90wv'}}>
                <h1>Ponuda:</h1>
                <hr/>
                {content}
            </div>);
        
    }

    async getStoreItems() {
        const response = await fetch('api/items');
        const data = await response.json();

        console.log(data);

        this.setState({items: data,loading: false});
        
    }
}