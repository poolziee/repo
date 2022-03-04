import '../../style/star-rating.css'

const {useState} = require("react");
const Star = ({selected = false, onClick = f => f}) => (
    <div className={selected ? "star selected" : "star"} onClick={onClick}/>
);

const StaticStar = ({selected = false}) => (
    <div className={selected ? "star selected" : "star"}/>
);


const StarRating = ({parentalCallBack, givenStars, isStatic}) => {
    const [starsSelected, selectStar] = useState(givenStars);
    const totalStars = 5;
    if (givenStars > 0 && isStatic) {
        return (
            <div className="star-wrapper">
                <div className="star-rating">
                    {[...Array(totalStars)].map((n, i) => (
                        <StaticStar
                            key={i}
                            selected={i < starsSelected}
                        />
                    ))}
                </div>
            </div>
        );
    }

    return (
        <div>
            <div className="star-wrapper">
                <div className="star-rating">
                    {[...Array(totalStars)].map((n, i) => (
                        <Star
                            key={i}
                            selected={i < starsSelected}
                            onClick={() => {
                                selectStar(i + 1);
                                parentalCallBack('stars', i + 1);
                            }}
                        />
                    ))}
                    <p className="starInfo">
                        {starsSelected} of {totalStars} stars
                    </p>
                </div>
            </div>
        </div>
    );
};

export default StarRating
