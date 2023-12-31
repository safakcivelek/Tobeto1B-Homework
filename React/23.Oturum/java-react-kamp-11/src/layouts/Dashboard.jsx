import React from 'react';

import Categories from './Categories';
import ProductList from '../pages/ProductList';
import { Grid, GridColumn, GridRow } from 'semantic-ui-react'
import Navi from './Navi';

export default function Dashboard() {
    return (
        <div>               
            <Grid>
                <Grid.Row>
                    <GridColumn width={4}>
                        <Categories />
                    </GridColumn>
                    
                    <GridColumn width={12}>
                        <ProductList />
                    </GridColumn>
                </Grid.Row>
            </Grid>
        </div>
    )
}
