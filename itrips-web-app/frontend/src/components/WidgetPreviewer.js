import {useEffect} from 'react';
import PropTypes from 'prop-types';
import {Card, CardHeader, Divider} from '@material-ui/core';


const WidgetPreviewer = (props) => {
    const {element, name, ...other} = props;

    useEffect(() => {
    }, []);

    return (
        <Card
            variant="outlined"
            sx={{mb: 8}}
            {...other}
        >
            <CardHeader
                title={name}
            />
            <Divider/>
            {element}
        </Card>
    );
};

WidgetPreviewer.propTypes = {
    element: PropTypes.node.isRequired,
    name: PropTypes.string.isRequired
};

export default WidgetPreviewer;
