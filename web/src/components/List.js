import React from 'react'
import Item from './Item';
import { MdDelete } from 'react-icons/md'

function List({ items, handleEdit, handleDelete, clearItems }) {

    var category1 = items.filter(item => item.category.value === 1);
    var total1 = 0
    for (var item in category1) {
        total1 = parseInt(category1[item].amount) + total1;
    }
    var category2 = items.filter(item => item.category.value === 2);
    var total2 = 0
    for (var item in category2) {
        total2 = parseInt(category2[item].amount) + total2;
    }
    var category3 = items.filter(item => item.category.value === 3);
    var total3 = 0
    for (var item in category3) {
        total3 = parseInt(category3[item].amount) + total3;
    }

    return (
        <>
            <ul className="list">
            {
                category1.map(function (item, index){
                    if (index === 0) {
                        return (
                            <div>
                            <li className="item">
                            <div className="info">
                                <span className="expense">{item.category.label}</span>
                                <span className="amount">${total1}</span>
                            </div>
                            </li>
                            <Item key={item.id} item={item} handleDelete={handleDelete}/>
                            </div>)
                    }else 
                        return <Item key={item.id} item={item} handleDelete={handleDelete}/>
                })
            }
            </ul>
            <ul className="list">
            {
                category2.map(function (item, index){
                    if (index === 0) {
                        return (
                            <div>
                            <li className="item">
                            <div className="info">
                                <span className="expense">{item.category.label}</span>
                                <span className="amount">${total2}</span>
                            </div>
                            </li>
                            <Item key={item.id} item={item} handleDelete={handleDelete}/>
                            </div>)
                    }else 
                        return <Item key={item.id} item={item} handleDelete={handleDelete}/>
                })
            }
            </ul>
            <ul className="list">
            {
                category3.map(function (item, index){
                    if (index === 0) {
                        return (
                            <div>
                            <li className="item">
                            <div className="info">
                                <span className="expense">{item.category.label}</span>
                                <span className="amount">${total3}</span>
                            </div>
                            </li>
                            <Item key={item.id} item={item} handleDelete={handleDelete}/>
                            </div>)
                    }else 
                        return <Item key={item.id} item={item} handleDelete={handleDelete}/>
                })
            }
            </ul>
            {items.length > 0 && (
                <button className="btn" onClick={clearItems}>
                    clear Items<MdDelete className="btn-icon" />
                </button>
            )}
        </>
    )
}

export default List